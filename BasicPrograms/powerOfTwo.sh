#! /bin/bash
read -p 'enter the value: ' value
if [ $value -gt 0 -a $value -lt 31 ]
then
for (( i=1;i<value;i++ )) 
do
awk -v var=$i 'BEGIN { print (2^var)}'
done
else 
echo "invaild number"
fi
