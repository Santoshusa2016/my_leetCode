#include <stdio.h>
#include <stdlib.h>

int lenOfArray(int data){
    int m = data;
    int digit = 0;
    while (m) {
        printf("Value of m %d", m);
        digit++; 
        // Truncate the last digit from the number 
        m /= 10; 
    }
    return digit;
}

long reverse(int data){
    int arrayLen = lenOfArray(data);
    int *arr = (int *)malloc(4 * arrayLen);
    long retlongVal = 0;

    for (int i = 0; i < arrayLen; i++)
    {
        int value = data%10;       
        *(arr + i ) = value;
        data /= 10;
    }
   
    for (int i = 0; i < arrayLen; i++)
    { 
      retlongVal = 10 * retlongVal + *(arr + i);          
    }

    printf("%ld \n", retlongVal);
    if(retlongVal > INT_MAX || retlongVal < INT_MIN){
        
        return 0;
    }
    return retlongVal;
}

void main(){
    int num; 
    long revnum;
    printf("type a number \n");
    int converted = scanf("%d", &num);
    //Check if input is valid number
    if( converted == 0) 
    {
        printf("Invalid Input");
    }
    else{
        revnum = reverse(num);
        printf("Reverse of number is:%d", revnum);
    }
}

