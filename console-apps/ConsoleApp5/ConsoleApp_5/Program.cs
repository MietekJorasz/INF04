namespace ConsoleApp_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
			int n = 100;
			int[] numsArray = new int[n + 1];
			bool[] isPrime = new bool[n + 1];
			Array.Fill(isPrime, true);

			isPrime[0] = false;
			isPrime[1] = false;

			fillArray(numsArray);

			for (int i = 2; i * i <= n; i++)
			{
				if (isPrime[i])
				{
					for (int j = i * i; j <= n; j += i)
					{
						isPrime[j] = false;
					}
				}
			}

			for (int i = 2; i <= n; i++)
			{
				if (isPrime[i])
					Console.Write(numsArray[i] + ", ");
			}

		}

		static void fillArray(int[] nums)
        {
			for (int i = 0; i < nums.Length; i++)
			{
				nums[i] = i;
			}
		}
    }
}
