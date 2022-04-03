namespace Coursework2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SolveButton_Click(object sender, EventArgs e)
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
            if (rootchord <= 0 || rootchord > 50) { LiftingLineSolver.ErrorMsg("span"); chordBox.Clear(); return; }
            if (taper < 0 || taper > 2) { LiftingLineSolver.ErrorMsg("span"); taperBox.Clear(); return; }
            if (slope <= 0 || slope > 20) { LiftingLineSolver.ErrorMsg("span"); liftCurveBox.Clear(); return; }
            if (alpha < -15 || alpha > 15) { LiftingLineSolver.ErrorMsg("span"); zeroLiftBox.Clear(); return; }
            if (washout < -10 || washout > -10) { LiftingLineSolver.ErrorMsg("span"); washoutBox.Clear(); return; }
            if (AoA < -15 || AoA > 15) { LiftingLineSolver.ErrorMsg("span"); angleBox.Clear(); return; }

            //Creater solver object
            LiftingLineSolver Solver = new LiftingLineSolver(span, rootchord, taper, slope, alpha, washout, AoA);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InfoButton_Click(object sender, EventArgs e)
        {

        }

        public class LiftingLineSolver //Lifting Line Solver Class
        {
            //Input Property Fields
            public double span { get; set; }
            public double chord { get; set; }
            public double taper { get; set; }
            public double slope { get; set; }
            public double zerolift { get; set; }
            public double washout { get; set; }
            public double AoA { get; set; }

            //Constructor
            public LiftingLineSolver(double wingspan = 1, double rootchord = 1, double wingtaper = 1, double liftslope = 5, double zeroangle = 0, double wingwashout = 0, double angleofAttack = 1)
            {
                span = wingspan; chord = rootchord; taper = wingtaper; slope = liftslope; zerolift = zeroangle; washout = wingwashout; AoA = angleofAttack; //Setting inputs
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

        }


        public class MatrixMethods
        {
            // #############################################################
            //                 matrix methods
            //
            // https://jamesmccaffrey.wordpress.com/2015/03/06/inverting-a-matrix-using-c/
            //
            //############################################################## 

            static double[][] MatrixCreate(int rows, int cols)

            {
                double[][] result = new double[rows][];
                for (int i = 0; i < rows; ++i)
                    result[i] = new double[cols];
                return result;
            }

            static double[][] MatrixIdentity(int n)
            {
                // return an n x n Identity matrix
                double[][] result = MatrixCreate(n, n);
                for (int i = 0; i < n; ++i)
                    result[i][i] = 1.0;
                return result;
            }

            static double[][] MatrixRandom(int rows, int cols, double minVal, double maxVal, int seed)
            {
                // return a matrix with random values
                Random ran = new Random(seed);
                double[][] result = MatrixCreate(rows, cols);
                for (int i = 0; i < rows; ++i)
                    for (int j = 0; j < cols; ++j)
                        result[i][j] = (maxVal - minVal) * ran.NextDouble() + minVal;
                return result;
            }

            static string MatrixAsString(double[][] matrix, int dec)
            {
                string s = "";
                for (int i = 0; i < matrix.Length; ++i)
                {
                    for (int j = 0; j < matrix[i].Length; ++j)
                        s += matrix[i][j].ToString("F" + dec).PadLeft(8) + " ";
                    s += Environment.NewLine;
                }
                return s;
            }

            static bool MatrixAreEqual(double[][] matrixA, double[][] matrixB, double epsilon)
            {
                // true if all values in matrixA == values in matrixB
                int aRows = matrixA.Length; int aCols = matrixA[0].Length;
                int bRows = matrixB.Length; int bCols = matrixB[0].Length;
                if (aRows != bRows || aCols != bCols)
                    throw new Exception("Non-conformable matrices");

                for (int i = 0; i < aRows; ++i) // each row of A and B
                    for (int j = 0; j < aCols; ++j) // each col of A and B
                                                    //if (matrixA[i][j] != matrixB[i][j])
                        if (Math.Abs(matrixA[i][j] - matrixB[i][j]) > epsilon)
                            return false;
                return true;
            }

            static double[][] MatrixProduct(double[][] matrixA, double[][] matrixB)
            {
                int aRows = matrixA.Length; int aCols = matrixA[0].Length;
                int bRows = matrixB.Length; int bCols = matrixB[0].Length;
                if (aCols != bRows)
                    throw new Exception("Non-conformable matrices in MatrixProduct");

                double[][] result = MatrixCreate(aRows, bCols);

                for (int i = 0; i < aRows; ++i) // each row of A
                    for (int j = 0; j < bCols; ++j) // each col of B
                        for (int k = 0; k < aCols; ++k) // could use k less-than bRows
                            result[i][j] += matrixA[i][k] * matrixB[k][j];

                //Parallel.For(0, aRows, i =greater-than
                //  {
                //    for (int j = 0; j less-than bCols; ++j) // each col of B
                //      for (int k = 0; k less-than aCols; ++k) // could use k less-than bRows
                //        result[i][j] += matrixA[i][k] * matrixB[k][j];
                //  }
                //);

                return result;
            }

            static double[] MatrixVectorProduct(double[][] matrix, double[] vector)
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

            static double[][] MatrixInverse(double[][] matrix)
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

            static double MatrixDeterminant(double[][] matrix)
            {
                int[] perm;
                int toggle;
                double[][] lum = MatrixDecompose(matrix, out perm, out toggle);
                if (lum == null)
                    throw new Exception("Unable to compute MatrixDeterminant");
                double result = toggle;
                for (int i = 0; i < lum.Length; ++i)
                    result *= lum[i][i];
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

            static double[] SystemSolve(double[][] A, double[] b)
            {
                // Solve Ax = b
                int n = A.Length;

                // 1. decompose A
                int[] perm;
                int toggle;
                double[][] luMatrix = MatrixDecompose(A, out perm,
                  out toggle);
                if (luMatrix == null)
                    return null;

                // 2. permute b according to perm[] into bp
                double[] bp = new double[b.Length];
                for (int i = 0; i < n; ++i)
                    bp[i] = b[perm[i]];

                // 3. call helper
                double[] x = HelperSolve(luMatrix, bp);
                return x;
            } // SystemSolve

            static double[][] MatrixDuplicate(double[][] matrix)
            {
                // allocates/creates a duplicate of a matrix.
                double[][] result = MatrixCreate(matrix.Length, matrix[0].Length);
                for (int i = 0; i < matrix.Length; ++i) // copy the values
                    for (int j = 0; j < matrix[i].Length; ++j)
                        result[i][j] = matrix[i][j];
                return result;
            }

            static double[] MatrixBackSub(double[][] luMatrix, int[] indx, double[] b)
            {
                int rows = luMatrix.Length;
                int cols = luMatrix[0].Length;
                if (rows != cols)
                    throw new Exception("Non-square LU mattrix");

                int ii = 0; int ip = 0;
                int n = b.Length;
                double sum = 0.0;

                double[] x = new double[b.Length];
                b.CopyTo(x, 0);

                for (int i = 0; i < n; ++i)
                {
                    ip = indx[i];
                    sum = x[ip];
                    x[ip] = x[i]; //
                    if (ii == 0)
                    {
                        for (int j = ii; j <= i - 1; ++j)
                        {
                            sum -= luMatrix[i][j] * x[j];
                        }
                    }
                    else if (sum == 0.0)
                    {
                        ii = i;
                    }
                    x[i] = sum;
                } // i

                for (int i = n - 1; i >= 0; --i) // note I change increment from -i to --i
                {
                    sum = x[i];
                    for (int j = i + 1; j < n; ++j)
                    { sum -= luMatrix[i][j] * x[j]; }
                    x[i] = sum / luMatrix[i][i];
                }
                return x;
            } // MatrixBackSub

            // ####################################################
        }


    }
}