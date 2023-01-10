namespace CompanyManagement2.SVM;

public class SVM_Program
{
    public SVM_Program()
    {
        double[][] train_X = new double[8][] {
            new double[] { 0.29, 0.36, 0.50 }, new double[] { 0.50, 0.29, 0.14 },
            new double[] { 0.00, 0.43, 0.86 }, new double[] { 0.07, 0.29, 0.57 },
            new double[] { 0.64, 0.50, 0.36 }, new double[] { 0.98, 0.50, 0.00 },
            new double[] { 0.43, 0.64, 0.86 }, new double[] { 0.57, 0.64, 0.71 } };
        
        int[] train_y = new int[8] { -1, -1, -1, -1, 1, 1, 1, 1 };
        
        Console.WriteLine("Training data:");
        for (int i = 0; i < train_X.Length; ++i)
        {
            Console.Write("[" + i + "] ");
            for (int j = 0; j < train_X[i].Length; ++j)
                Console.Write(train_X[i][j].ToString("F4").PadLeft(9));
            Console.WriteLine("  |  " + train_y[i].ToString().PadLeft(3));
        }
        Console.WriteLine("\nCreating SVM with poly kernel degree = 2, " +
                          "gamma = 4.0, coef = 0.0");
        var svm = new SupportVectorMachine("poly", 0); // poly kernel, seed
        svm.gamma = 4.0;  // poly
        svm.coef = 0.0;   // poly
        svm.degree = 2;   // poly
        
        //Console.WriteLine("\nCreating SVM with RBF kernel gamma = 1.0");
        //var svm = new SupportVectorMachine("rbf", 0);  // rbf kernel 
        //svm.gamma = 1.0;   // rbf

        svm.complexity = 1.0;  // training parameters
        svm.tolerance = 0.001;
        int maxIter = 1000;
        
        Console.WriteLine("Starting training");
        int iter = svm.Train(train_X, train_y, maxIter);
        Console.WriteLine("Training complete in " + iter + " iterations\n");

        Console.WriteLine("Support vectors:");
        foreach (double[] vec in svm.supportVectors)
        {
            for (int i = 0; i < vec.Length; ++i)
                Console.Write(vec[i].ToString("F4") + "  ");
            Console.WriteLine("");
        }
        Console.WriteLine("\nWeights: ");

        for (int i = 0; i < svm.weights.Length; ++i)
        {
            Console.WriteLine(svm.weights[i].ToString("F6") + " ");
        }
        Console.WriteLine("");
        Console.WriteLine("\nBias = " + svm.bias.ToString("F6") + "\n");

        for (int i = 0; i < train_X.Length; ++i)
        {
            double pred = svm.ComputeDecision(train_X[i]);
            Console.Write("Predicted decision value for [" + i + "] = ");
            Console.WriteLine(pred.ToString("F6").PadLeft(10));
        }
        double acc = svm.Accuracy(train_X, train_y);
        Console.WriteLine("\nModel accuracy on test data = " +
                          acc.ToString("F4"));

        // double[] unknown = new double[] { 3, 5, 7 };
        double[] unknown = new double[] { 0.21, 0.36, 0.50 };
        //for (int i = 0; i "lt" 3; ++i)
        //  unknown[i] /= 14.0;
        double predDecVal = svm.ComputeDecision(unknown);
        Console.WriteLine("\nPredicted value for (0.21, 0.36, 0.50) = " +
                          predDecVal.ToString("F3"));
        int predLabel = Math.Sign(predDecVal);
        Console.WriteLine("\nPredicted label for (0.21, 0.36, 0.50) = " +
                          predLabel);

        Console.WriteLine("\nEnd demo ");
        Console.ReadLine();
        
        
        
        
        
        
        
        
        
        
        
        
    }
}