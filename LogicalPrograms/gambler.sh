#! /bin/bash
read -p 'enter your dream (goal) amount: ' goal
read -p 'enter how much amount you have: ' total
stake=1
loss=0
win=0
while [ $total -gt 0 -a $total -lt $goal ]
do
  read -p 'enter stake amount: ' stake
  if [ $stake -gt $total ]
  then
  echo "you don't have that much amount..enter once again"
  read -p 'enter stake amount : ' stake
  elif [ $stake -eq 0 ]
  then
  echo "enter amount......................................"
  read -p 'enter stake amount: '
  fi
rn=$( shuf -i 0-1 -n 1 )
if [ $rn -eq 0 ]
then
echo "you lossed your money"
(( loss++ ))
let "total-=$stake"
echo "you have $total rs"
else
echo "you won"
(( win++ ))
let "total+=$stake"
echo "you have $total rs"
fi
done
if [ $total -gt $goal ]
then
echo "your goal amount is less your total amount,pls add some amount to your goal"
fi
per=$(( $win/$loss ))
echo "percentage of win and loss is $per"

