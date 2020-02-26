#! /bin/bash
declare array
count=0
read -p 'enter the size of an array: ' size
for (( i=1;i<=$size;i++ ))
do
read -p 'enter the value: ' value
array[$i]=$value
done
length=${#array[@]}
for (( i=1;i<=$length;i++ ))
do
for (( j=1;j<=$length;j++ ))
do
for (( k=1;k<=$length;k++ ))
do
if [ $((${array[$i]}+${array[$j]}+${array[$k]})) -eq 0 ]
then
echo "sum of triplets : ${array[$i]},${array[$j]},${array[$k]}"
(( count++ ))
fi
done
done
done
echo "number of triplets: $count"


