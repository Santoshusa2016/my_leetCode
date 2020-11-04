#include<stdio.h> 
#include<stdlib.h> 
  
  int addOvf(int* result, int a, int b) 
 { 
    *result = a + b; 
    printf("result Val %d\n", result);
    printf("result Address %p\n", result);
    printf("result Val * %d\n", *result);


     if(a > 0 && b > 0 && *result < 0) 
         return -1; 
     if(a < 0 && b < 0 && *result > 0) 
         return -1; 
     return 0; 
 } 
  
 int main() 
 { 
     int *res = (int *)malloc(sizeof(int)); 
     int x = 21474836; 
     int y = 10; 
  
     printf("%d", addOvf(res, x, y)); 
  
     printf("\n %d", *res); 
     getchar(); 
     return 0; 
} 