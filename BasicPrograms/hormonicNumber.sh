#! /bin/bash
read -p 'enter the number: ' num
if [ $num -eq 0 ]
then 
echo "invalid number"
else
sum=0
for (( i=1;i<=$num;i++ ))
do
sum=$( awk -v  i=$i -v sum=$sum 'BEGIN {print (sum+1/i)}')
done 
echo "$num th harmonic number is $sum"
fi
