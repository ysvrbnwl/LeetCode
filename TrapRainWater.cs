public class Solution
  {
      public int Trap(int[] height)
      {
          if (height.Length < 3)
          {
              return 0;
          }
          var middleStick = Array.IndexOf(height, height.Max());

          var leftArray = height.Take(middleStick).ToArray();
          var leftStick = leftArray.Length > 1 ? Array.IndexOf(leftArray, leftArray.Max()) : 0;

          var rightArray = height.Skip(middleStick + 1).ToArray();
          var rightStick = rightArray.Length > 1 ? Array.IndexOf(rightArray, rightArray.Max()) + 1 + middleStick : middleStick;

          var leftWater = CalculateWater(height, leftStick, middleStick);
          var rightWater = CalculateWater(height, middleStick, rightStick);
          var totalWater = leftWater + rightWater;

          return Trap(height.Take(leftStick + 1).ToArray()) + totalWater + Trap(height.Skip(rightStick).ToArray());

      }

      public int CalculateWater(int[] height, int begin, int end)
      {
          if (end - begin <= 1)
          {
              return 0;
          }

          var sum = 0;
          var shortTowerLength = (height[begin] >= height[end]) ? height[end] : height[begin];

          for (int i = begin; i < end; i++)
          {
              if (height[i] < shortTowerLength)
              {
                  sum = sum + (shortTowerLength - height[i]);
              }
          }

          return sum;
      }
  }
