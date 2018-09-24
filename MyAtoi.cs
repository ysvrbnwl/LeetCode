public class Solution
{
    public int MyAtoi(string str)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>() {
            { '1', 1 },
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 },
            { '0', 0 }
        };
        Int64 sum = 0;
        Int64 power = 1;
        bool calculationDone = false;
        str = str.Trim();

        for (int i = str.Length - 1; i >= 0; i--)
        {
            if (!calculationDone && !dict.ContainsKey(str[i]))
            {
                continue;
            }

            if (calculationDone && !dict.ContainsKey(str[i]) && i > 0)
            {
                sum = 0;
                power = 1;
                continue;
            }

            if (dict.ContainsKey(str[i]))
            {
                if (sum > int.MaxValue || power > int.MaxValue)
                {
                    continue;
                }
                calculationDone = true;
                sum = (power * dict[str[i]]) + sum;
                power = power * (Int64)10;
            }
            else if (str[i] == '-')
            {
                sum = sum * (-(Int64)1);
            }
            else if (str[i] == '.')
            {
                sum = 0;
                power = 1;
            }
        }

        return sum > int.MaxValue
                        ? int.MaxValue
                            : sum < int.MinValue
                        ? int.MinValue
                            : Convert.ToInt32(sum);
    }
}
