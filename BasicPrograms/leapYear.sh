#! /bin/bash
read -p 'enter the year ' year
if [ $year -gt 999 -a $year -lt  10000 ]
then
if [ $(($year%400 )) -eq 0 -o $(($year%4)) -eq 0 -a $(($year%100)) -ne 0 ]
then
echo "$year is a leap year"
else
echo "$year is not a leap year"
fi
else
echo "invalid   year"
fi
