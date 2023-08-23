#!/bin/bash

echo Hello! Log work on JIRA!

read -p "Enter issue number: " issue_number
read -p "Enter time spent: " time_spent

start "-- ADD ABSOLUTE PATH OF YOUR LogWork.exe --" $issue_number $time_spent