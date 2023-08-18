internal class Program
{
    int col, row;
    public bool SearchMatrix(int[][] matrix, int target)
    {
        this.row= matrix.Length;
        this.col= matrix[0].Length-1;

        int l = 0;int r = row-1;

        while (l <= r)
        {
            row= (l+r)/2;

            if(target > matrix[row][col])
            {
                l= row + 1;
            }else if(target < matrix[row][0])
            {
                r= row - 1;
            }
            else
            {
                break;
            }
        }

        if(l>r)
            return false;

        return BinarySerach(matrix[row], 0, col, target);
    }

    private bool BinarySerach(int[] matrix, int start, int end, int target)
    {
        while(start <= end)
        {
            int mid= (start+end)/2;
            if(target> matrix[mid])
                start= mid+1;
            else if(target < matrix[mid])
                end= mid-1;
            else if(target== matrix[mid])
                return true;
        }
        return false;
    }

    private static void Main(string[] args)
    {
        Program program = new Program();    
        Console.WriteLine(program.SearchMatrix(new int[][]
        {
            new int[]{1,3,5,7 },
            new int[] {10, 11, 16, 20},
            new int[] { 23, 30, 34, 60 }
        },3));
    }
}