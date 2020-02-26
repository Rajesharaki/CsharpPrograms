read -p 'enter the number: ' num
for (( i=2;i*i<=$num;i++ ))
do
while [ $(($num%$i)) -eq 0 ]
do
echo  "$i"
let "num/=i"
done
done
if [ $num -gt 0 ]
then
echo "$num"
fi
