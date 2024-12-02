package days

import (
	"fmt"
	"slices"
	"strconv"
	"strings"
)

type Day02 struct {
}

func init() {
	Register(2, func() Solution { return &Day02{} })
}

func (d *Day02) Part1(input string) any {
	var lines = strings.Split(input, "\n")
	var safe = 0
	for _, line := range lines {
		nums := strings.Split(line, " ")
		fmt.Println(nums)
		for i := 0; i < len(nums)-1; i++ {
			if isSafe(nums) {
				safe++
				break
			}
		}

	}
	return safe
}

func (d *Day02) Part2(input string) any {
	var lines = strings.Split(input, "\n")

	var safe = 0
	for _, line := range lines {
		nums := strings.Split(line, " ")
		fmt.Println(nums)
	outer:
		for i := 0; i < len(nums)-1; i++ {
			if isSafe(nums) {
				safe++
				break
			} else {
				for j := 0; j < len(nums); j++ {
					nums2 := make([]string, len(nums))
					copy(nums2, nums)
					nums2 = slices.Delete(nums2, j, j+1)
					if isSafe(nums2) {
						safe++
						break outer
					}
				}

			}

		}

	}
	return safe
}

func isSafe(nums []string) bool {
	var increasing bool
	var dirset bool
	for i := 0; i < len(nums)-1; i++ {
		num1, _ := strconv.Atoi(nums[i])
		num2, _ := strconv.Atoi(nums[i+1])
		dif := num1 - num2
		if !dirset {
			if dif > 0 {
				increasing = true
			}
			dirset = true
		}
		if increasing && dif < 0 {
			return false
		}
		if !increasing && dif > 0 {
			return false
		}
		if dif > 3 || dif < -3 {
			return false
		}
		if dif == 0 {
			return false
		}
	}
	return true
}
