using System;

//Saw answer in geeks since unable to determine the logic due to less apptitude skills
public class containerMaxWater {
    public int MaxArea(int[] height) {
    int i = 0, j = height.Length -1;
    int area = 0, maxArea = 0;
     while (i<j)
     {
         area = Math.Min(height[i], height[j]) * (j - i);
          if(height[i] < height[j])
              i++;
          else
              j--;
        maxArea = area < maxArea ? maxArea : area;
     }
     return maxArea;
    }

    public int MaxAreaOpt(int[] height) {
    int i = 0, j = height.Length -1;
    int area = 0, maxArea = 0;
    int preleft = 0, preright = 0;
     while (i<j)
     {
         area = Math.Min(height[i], height[j]) * (j - i);
          if(height[i] < height[j])
          {
            preleft= height[i];
            while (height[i] <= preleft && i<j)
                i++;
          }              
          else
          {
            preright= height[j];
            while (height[j] <= preright && i<j)
                j--;
          }
              
        maxArea = area < maxArea ? maxArea : area;
     }
     return maxArea;
    }
}