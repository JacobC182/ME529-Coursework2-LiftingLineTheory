namespace Coursework2
{
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); } //Initialising main form

        private void SolveButton_Click(object sender, EventArgs e) //Solve button routine - main program
        {
            //Input holding variables
            double span = new(); double rootchord = new(); double taper = new(); double slope = new(); double alpha = new(); double washout = new(); double AoA = new();

            //Validate Inputs - catch exceptions
            try { span = Convert.ToDouble(spanBox.Text); } catch (Exception) { LiftingLineSolver.ErrorMsg("span"); spanBox.Clear(); return; }
            try { rootchord = Convert.ToDouble(chordBox.Text); } catch (Exception) { LiftingLineSolver.ErrorMsg("chord"); chordBox.Clear(); return; }
            try { taper = Convert.ToDouble(taperBox.Text); } catch (Exception) { LiftingLineSolver.ErrorMsg("taper"); taperBox.Clear(); return; }
            try { slope = Convert.ToDouble(liftCurveBox.Text); } catch (Exception) { LiftingLineSolver.ErrorMsg("slope"); liftCurveBox.Clear(); return; }
            try { alpha = Convert.ToDouble(zeroLiftBox.Text); } catch (Exception) { LiftingLineSolver.ErrorMsg("zero"); zeroLiftBox.Clear(); return; }
            try { washout = Convert.ToDouble(washoutBox.Text); } catch (Exception) { LiftingLineSolver.ErrorMsg("washout"); washoutBox.Clear(); return; }
            try { AoA = Convert.ToDouble(angleBox.Text); } catch (Exception) { LiftingLineSolver.ErrorMsg("AoA"); angleBox.Clear(); return; }

            //Validate Inputs - value checking
            if (span <= 0 || span > 200) { LiftingLineSolver.ErrorMsg("span"); spanBox.Clear(); return; }
            if (rootchord <= 0 || rootchord > 200) { LiftingLineSolver.ErrorMsg("chord"); chordBox.Clear(); return; }
            if (taper < 0 || taper > 5) { LiftingLineSolver.ErrorMsg("taper"); taperBox.Clear(); return; }
            if (slope <= 0 || slope > 25) { LiftingLineSolver.ErrorMsg("slope"); liftCurveBox.Clear(); return; }
            if (alpha < -15 || alpha > 15) { LiftingLineSolver.ErrorMsg("zero"); zeroLiftBox.Clear(); return; }
            if (washout < -10 || washout > 10) { LiftingLineSolver.ErrorMsg("washout"); washoutBox.Clear(); return; }
            if (AoA < -15 || AoA > 15) { LiftingLineSolver.ErrorMsg("AoA"); angleBox.Clear(); return; }

            //Create solver object
            LiftingLineSolver Solver = new LiftingLineSolver(span, rootchord, taper, slope, alpha, washout, AoA);

            //Calculate A1,3,5,7 Coefficients
            double[] A = Solver.CoefficientSolve();
            double[] CLCD = Solver.LiftDragSolve();

            //Print output values on form
            A1Box.Text = A[0].ToString(); A3Box.Text = A[1].ToString(); A5Box.Text = A[2].ToString(); A7Box.Text = A[3].ToString();
            LiftBox.Text = CLCD[0].ToString(); DragBox.Text = CLCD[1].ToString();

            //Drawing wing plan
            Solver.DrawWing(panel1);
        }

        private void Form1_Load(object sender, EventArgs e) { } //on form1 loading - (anything that should happen immediately on launch

        private void InfoButton_Click(object sender, EventArgs e) { Form2 form2 = new Form2(); form2.Show(); } //Info button - display info form

        public class LiftingLineSolver //Lifting Line Solver Class
        {
            //Input Property Fields - names are explanatory of what they are for
            public double span { get; set; }
            public double chord { get; set; }
            public double taper { get; set; }
            public double slope { get; set; }
            public double zerolift { get; set; }
            public double washout { get; set; }
            public double AoA { get; set; }

            //Output Property Fields
            public double AR { get; set; }
            public double[] Acoeff { get; set; }
            public double CL { get; set; }
            public double CD { get; set; }

            //Constructor
            public LiftingLineSolver(double wingspan = 1, double rootchord = 1, double wingtaper = 1, double liftslope = 5, double zeroangle = 0, double wingwashout = 0, double angleofAttack = 1)
            {
                span = wingspan; chord = rootchord; taper = wingtaper; slope = liftslope; zerolift = zeroangle; washout = wingwashout; AoA = angleofAttack; //Setting inputs
                AR = wingspan / ((rootchord + (rootchord * wingtaper)) / 2); //setting aspect ratio
                Acoeff = new double[4]; //setting blank array to avoid null error
            }

            //Quick Error Message methods
            public static void ErrorMsg(string NameStr)
            {
                string ErrorStr = "";
                switch (NameStr)
                {
                    case "span":
                        ErrorStr = "Wing Span is not valid, please enter a valid Span between 0 and 200 metres"; break;
                    case "chord":
                        ErrorStr = "Wing Root Chord is not valid, please enter a valid Root Chord between 0 and 50 metres"; break;
                    case "taper":
                        ErrorStr = "Wing Taper Ratio is not valid, please enter a valid Taper ratio between 0 and 2"; break;
                    case "slope":
                        ErrorStr = "Wing Lift Curve Slope is not valid, please enter a valid Lift Curve Slope between 0 and 20/rad"; break;
                    case "zero":
                        ErrorStr = "Wing Zero Lift Angle is not valid, please enter a valid Zero Lift Angle between -15 and +15 degrees"; break;
                    case "washout":
                        ErrorStr = "Wing Washout is not valid, please enter a valid Washout between -10 and +10 degrees"; break;
                    case "AoA":
                        ErrorStr = "Wing Angle of Attack is not valid, please enter a valid Angle of Attack between -15 and +15 degrees"; break;

                    default:
                        ErrorStr = "Error with Inputs, Please enter Valid Input Values"; break;
                }
                MessageBox.Show(ErrorStr); return;
            }

            public double[] CoefficientSolve()
            {
                int res = 4;

                double[] Fourier = { 1, 3, 5, 7 }; //4 term fourier coefficients
                AoA *= Math.PI / 180;
                zerolift *= Math.PI / 180;
                washout *= Math.PI / 180;
                double Hspan = span / 2;

                double tipchord = chord * taper; // calculate tip chord

                double[][] A = MatrixMethods.MatrixCreate(res, res); //Create A matrix for simultaneous equation solving
                double[] b = new double[res]; //Create b vector for simultaneous equations

                for (int i = 0; i < res; i++)
                {
                    double fraction = Convert.ToDouble(i + 1); //fraction of distance along wing
                    double a = Math.Acos(-(fraction) / (res + 1)); //angular position

                    double chordfraction = chord - (chord - tipchord) * fraction / (res + 1); //calculate chord at distance fraction due to taper
                    double AoAfraction = AoA - washout * fraction / (res + 1);  //calculate Angle of Attack at distance fraction due to washout
                    double u = chordfraction * slope / (Hspan * 8);    //calculate u

                    b[i] = u * (AoAfraction - zerolift) * Math.Sin(a); //assemble b vector for simultaneous equation solving

                    for (int j = 0; j < res; j++)
                    {
                        A[i][j] = Math.Sin(Fourier[j] * a) * (u * Fourier[j] + Math.Sin(a)); //Monoplane equation into matrix
                    }
                }
                A = MatrixMethods.MatrixInverse(A); //Invert matrix A to A^-1
                Acoeff = MatrixMethods.MatrixVectorProduct(A, b); //solving simultaneous equations from matrix / vector A / b

                return Acoeff; //returning A1357 coefficients 
            }

            public double[] LiftDragSolve() //Solving lift and drag coefficient routine
            {
                CL = Acoeff[0] * Math.PI * AR; //calculate lift coefficient

                double CDa = 1; double[] Fourier = { 3, 5, 7 }; //drag coefficient calculation additional values
                for (int i = 0; i < 3; i++) { CDa += Fourier[i] * Math.Pow(Acoeff[i + 1], 2) / Math.Pow(Acoeff[0], 2); } //calculating sum for CD

                CD = ((CL * CL) / (Math.PI * AR)) * CDa; //calculate drag coefficient

                double[] output = { CL, CD };
                return output; //return coefficients in array
            }

            public void DrawWing(Panel p) //Drawing wing plan routine - give panel form object
            {
                //This drawing method is somewhat robust and adjusts the drawing scales for different spans and chords, it will represent the true nature of the wing shape.
                //e.g. drawing a wing with a wider span will make the chord appear proportionately thinner, and vice versa.
                //This method does not deal with wings that have a MUCH greater chord than span, it can deal with some slightly long-chord wings, but only to a certain point.
                // (Around a 1.5:1 chord to span ratio is the max with this implementation
                //This method is based on the idea of a constant drawing span width, and either scales or bases all other dimensions on the constant span.

                p.Refresh(); //Refresh drawing (Clean the whiteboard)
                int centreX = p.Width / 2; int centreY = p.Height / 2; //getting centre panel coords

                //Drawing pens
                Pen blackpen = new Pen(Color.Black, 2); Pen bluepen = new Pen(Color.Blue, 2); Pen redpen = new Pen(Color.Red, 2);

                Graphics g = p.CreateGraphics(); //Creating graphics object for panel
                g.TranslateTransform(centreX, centreY); //setting origin to centre of panel

                int fuse = 20; //fuselage centre width
                

                double dspan = centreX - fuse - 1; //drawing span - always constant

                double chordspan = chord / (span / 2); //calcuating chord as ratio of constant span

                if (span / 2 < chord) { g.ScaleTransform(1 / Convert.ToSingle(chordspan), Convert.ToSingle(chordspan)); } //checking for chord-long wing, and scaling

                int dchord = Convert.ToInt32(chordspan * dspan); int dtipchord = Convert.ToInt32(chordspan * dspan * taper); //calculating drawing distances for chord

                //drawing fuselage
                g.DrawLine(blackpen, new Point(-fuse, centreY), new Point(-fuse, -centreY)); g.DrawLine(blackpen, new Point(fuse, centreY), new Point(fuse, -centreY));

                //Drawing span lines
                g.DrawLine(bluepen, new Point(-centreX + 1, 0), new Point(-fuse, 0));
                g.DrawLine(bluepen, new Point(centreX - 1, 0), new Point(fuse, 0));

                //Drawing root chord lines
                g.DrawLine(redpen, new Point(fuse, dchord / 2), new Point(fuse, -dchord / 2));
                g.DrawLine(redpen, new Point(-fuse, dchord / 2), new Point(-fuse, -dchord / 2));

                //drawing tip chord lines
                g.DrawLine(redpen, new Point(centreX - 1, dtipchord / 2), new Point(centreX - 1, -dtipchord / 2));
                g.DrawLine(redpen, new Point(-centreX + 1, dtipchord / 2), new Point(-centreX + 1, -dtipchord / 2));

                //drawing upper wing edges
                g.DrawLine(blackpen, new Point(fuse, -dchord / 2), new Point(centreX - 1, -dtipchord / 2));
                g.DrawLine(blackpen, new Point(-fuse, -dchord / 2), new Point(-centreX + 1, -dtipchord / 2));

                //drawing lower wing edges
                g.DrawLine(blackpen, new Point(fuse, dchord / 2), new Point(centreX - 1, dtipchord / 2));
                g.DrawLine(blackpen, new Point(-fuse, dchord / 2), new Point(-centreX + 1, dtipchord / 2));
            }

            public class MatrixMethods //class containing matrix methods supplied - source below
            {
                // #############################################################
                //                 matrix methods
                //
                // https://jamesmccaffrey.wordpress.com/2015/03/06/inverting-a-matrix-using-c/
                //
                //############################################################## 

                public static double[][] MatrixCreate(int rows, int cols)

                {
                    double[][] result = new double[rows][];
                    for (int i = 0; i < rows; ++i)
                        result[i] = new double[cols];
                    return result;
                }

                public static double[] MatrixVectorProduct(double[][] matrix, double[] vector)
                {
                    // result of multiplying an n x m matrix by a m x 1 
                    // column vector (yielding an n x 1 column vector)
                    int mRows = matrix.Length; int mCols = matrix[0].Length;
                    int vRows = vector.Length;
                    if (mCols != vRows)
                        throw new Exception("Non-conformable matrix and vector");
                    double[] result = new double[mRows];
                    for (int i = 0; i < mRows; ++i)
                        for (int j = 0; j < mCols; ++j)
                            result[i] += matrix[i][j] * vector[j];
                    return result;
                }

                static double[][] MatrixDecompose(double[][] matrix, out int[] perm, out int toggle)
                {
                    // Doolittle LUP decomposition with partial pivoting.
                    // rerturns: result is L (with 1s on diagonal) and U;
                    // perm holds row permutations; toggle is +1 or -1 (even or odd)
                    int rows = matrix.Length;
                    int cols = matrix[0].Length; // assume square
                    if (rows != cols)
                        throw new Exception("Attempt to decompose a non-square m");

                    int n = rows; // convenience

                    double[][] result = MatrixDuplicate(matrix);

                    perm = new int[n]; // set up row permutation result
                    for (int i = 0; i < n; ++i) { perm[i] = i; }

                    toggle = 1; // toggle tracks row swaps.
                                // +1 -greater-than even, -1 -greater-than odd. used by MatrixDeterminant

                    for (int j = 0; j < n - 1; ++j) // each column
                    {
                        double colMax = Math.Abs(result[j][j]); // find largest val in col
                        int pRow = j;
                        //for (int i = j + 1; i less-than n; ++i)
                        //{
                        //  if (result[i][j] greater-than colMax)
                        //  {
                        //    colMax = result[i][j];
                        //    pRow = i;
                        //  }
                        //}

                        // reader Matt V needed this:
                        for (int i = j + 1; i < n; ++i)
                        {
                            if (Math.Abs(result[i][j]) > colMax)
                            {
                                colMax = Math.Abs(result[i][j]);
                                pRow = i;
                            }
                        }
                        // Not sure if this approach is needed always, or not.

                        if (pRow != j) // if largest value not on pivot, swap rows
                        {
                            double[] rowPtr = result[pRow];
                            result[pRow] = result[j];
                            result[j] = rowPtr;

                            int tmp = perm[pRow]; // and swap perm info
                            perm[pRow] = perm[j];
                            perm[j] = tmp;

                            toggle = -toggle; // adjust the row-swap toggle
                        }

                        // --------------------------------------------------
                        // This part added later (not in original)
                        // and replaces the 'return null' below.
                        // if there is a 0 on the diagonal, find a good row
                        // from i = j+1 down that doesn't have
                        // a 0 in column j, and swap that good row with row j
                        // --------------------------------------------------

                        if (result[j][j] == 0.0)
                        {
                            // find a good row to swap
                            int goodRow = -1;
                            for (int row = j + 1; row < n; ++row)
                            {
                                if (result[row][j] != 0.0)
                                    goodRow = row;
                            }

                            if (goodRow == -1)
                                throw new Exception("Cannot use Doolittle's method");

                            // swap rows so 0.0 no longer on diagonal
                            double[] rowPtr = result[goodRow];
                            result[goodRow] = result[j];
                            result[j] = rowPtr;

                            int tmp = perm[goodRow]; // and swap perm info
                            perm[goodRow] = perm[j];
                            perm[j] = tmp;

                            toggle = -toggle; // adjust the row-swap toggle
                        }
                        // --------------------------------------------------
                        // if diagonal after swap is zero . .
                        //if (Math.Abs(result[j][j]) less-than 1.0E-20) 
                        //  return null; // consider a throw

                        for (int i = j + 1; i < n; ++i)
                        {
                            result[i][j] /= result[j][j];
                            for (int k = j + 1; k < n; ++k)
                            {
                                result[i][k] -= result[i][j] * result[j][k];
                            }
                        }


                    } // main j column loop

                    return result;
                } // MatrixDecompose

                public static double[][] MatrixInverse(double[][] matrix)
                {
                    int n = matrix.Length;
                    double[][] result = MatrixDuplicate(matrix);

                    int[] perm;
                    int toggle;
                    double[][] lum = MatrixDecompose(matrix, out perm, out toggle);
                    if (lum == null)
                        throw new Exception("Unable to compute inverse");

                    double[] b = new double[n];
                    for (int i = 0; i < n; ++i)
                    {
                        for (int j = 0; j < n; ++j)
                        {
                            if (i == perm[j])
                                b[j] = 1.0;
                            else
                                b[j] = 0.0;
                        }

                        double[] x = HelperSolve(lum, b); // 

                        for (int j = 0; j < n; ++j)
                            result[j][i] = x[j];
                    }
                    return result;
                }

                static double[] HelperSolve(double[][] luMatrix, double[] b)
                {
                    // before calling this helper, permute b using the perm array
                    // from MatrixDecompose that generated luMatrix
                    int n = luMatrix.Length;
                    double[] x = new double[n];
                    b.CopyTo(x, 0);

                    for (int i = 1; i < n; ++i)
                    {
                        double sum = x[i];
                        for (int j = 0; j < i; ++j)
                            sum -= luMatrix[i][j] * x[j];
                        x[i] = sum;
                    }

                    x[n - 1] /= luMatrix[n - 1][n - 1];
                    for (int i = n - 2; i >= 0; --i)
                    {
                        double sum = x[i];
                        for (int j = i + 1; j < n; ++j)
                            sum -= luMatrix[i][j] * x[j];
                        x[i] = sum / luMatrix[i][i];
                    }

                    return x;
                }

                static double[][] MatrixDuplicate(double[][] matrix)
                {
                    // allocates/creates a duplicate of a matrix.
                    double[][] result = MatrixCreate(matrix.Length, matrix[0].Length);
                    for (int i = 0; i < matrix.Length; ++i) // copy the values
                        for (int j = 0; j < matrix[i].Length; ++j)
                            result[i][j] = matrix[i][j];
                    return result;
                }

                // ####################################################
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e) { } //panel painting method override
    }
}