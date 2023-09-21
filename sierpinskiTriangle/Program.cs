// See https://aka.ms/new-console-template for more information
using System;

using System;

class Mandelbrot
{
    static void Main()
    {
        const int width = 80;
        const int height = 24;
        const double xmin = -2.0;
        const double xmax = 1.0;
        const double ymin = -1.0;
        const double ymax = 1.0;
        const int maxIter = 1000;

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                double x = xmin + (xmax - xmin) * col / (width - 1);
                double y = ymin + (ymax - ymin) * row / (height - 1);

                int iteration = ComputeMandelbrot(x, y, maxIter);

                char asciiChar = iteration == maxIter ? ' ' : GetAsciiChar(iteration);

                Console.Write(asciiChar);
            }
            Console.WriteLine();
        }
    }

    static int ComputeMandelbrot(double x, double y, int maxIter)
    {
        double zx = 0;
        double zy = 0;
        int iteration = 0;

        while (iteration < maxIter && zx * zx + zy * zy < 4)
        {
            double newZx = zx * zx - zy * zy + x;
            zy = 2 * zx * zy + y;
            zx = newZx;
            iteration++;
        }

        return iteration;
    }

    static char GetAsciiChar(int iteration)
    {
        // You can customize the ASCII characters here based on the iteration count.
        // This function allows you to create different visual effects.
        char[] asciiChars = { '.', ',', ':', ';', 'o', 'O', 'X', 'M', '%' };

        int index = iteration % asciiChars.Length;
        return asciiChars[index];
    }
}


