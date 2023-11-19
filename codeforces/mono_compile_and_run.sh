#!/bin/bash

# Check if two arguments are given
if [ "$#" -ne 2 ]; then
    echo "Usage: $0 <source_file.cs> <output_file.out>"
    exit 1
fi

# Assign arguments to variables
SOURCE_FILE=$1
OUTPUT_FILE=$2

# Compile the C# source file
dmcs -define:ONLINE_JUDGE -o+ -out:$OUTPUT_FILE $SOURCE_FILE

# Check if compilation was successful
if [ $? -eq 0 ]; then
    # Run the compiled program using Mono
    mono $OUTPUT_FILE
else
    echo "Compilation failed"
    exit 1
fi
