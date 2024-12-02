package main

import (
	"aoc2024/common"
	"aoc2024/days"
	"fmt"
	"log"
	"os"
	"strconv"
)

func main() {
	if len(os.Args) < 3 {
		log.Fatal("Usage: go run main.go <day> <sample|live>")
	}

	day, err := strconv.Atoi(os.Args[1])
	if err != nil || day < 1 || day > 25 {
		log.Fatalf("Invalid day: %v. Must be between 1 and 25.", os.Args[1])
	}

	dataType := os.Args[2]
	if dataType != "sample" && dataType != "live" {
		log.Fatal("Invalid data type. Use 'sample' or 'live'.")
	}

	solver, err := days.GetSolution(day)
	if err != nil {
		log.Fatalf("Error: %v", err)
	}

	input := common.Load(day, dataType == "sample")

	fmt.Printf("Solutions for Day %02d (%s):\n", day, dataType)
	fmt.Printf("Part 1: %v\n", solver.Part1(input))
	fmt.Printf("Part 2: %v\n", solver.Part2(input))
}
