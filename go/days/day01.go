package days

import (
	"slices"
	"strconv"
	"strings"
)

type Day01 struct {
}

func init() {
	Register(1, func() Solution { return &Day01{} })
}

func (d *Day01) Part1(input string) any {
	var lines = strings.Split(input, "\n")
	var lnums []int
	var rnums []int
	for _, line := range lines {
		// fmt.Println(line)
		split := strings.Split(line, "   ")
		lnum, _ := strconv.Atoi(split[0])
		rnum, _ := strconv.Atoi(split[1])
		lnums = append(lnums, lnum)
		rnums = append(rnums, rnum)
	}
	slices.Sort(lnums)
	slices.Sort(rnums)
	//range over lnums and rnums and sum distances

	var sum int
	for i := 0; i < len(lnums); i++ {
		lnum := lnums[i]
		rnum := rnums[i]
		dist := rnum - lnum
		if dist < 0 {
			dist *= -1
		}
		sum += dist
	}
	return sum
}

func (d *Day01) Part2(input string) any {
	var lines = strings.Split(input, "\n")
	var lnums []int
	var rnums []int
	for _, line := range lines {
		// fmt.Println(line)
		split := strings.Split(line, "   ")
		lnum, _ := strconv.Atoi(split[0])
		rnum, _ := strconv.Atoi(split[1])
		lnums = append(lnums, lnum)
		rnums = append(rnums, rnum)
	}
	var sum int
	for i := 0; i < len(lnums); i++ {
		target := lnums[i]
		freq := 0
		for j := 0; j < len(lnums); j++ {
			if rnums[j] == target {
				freq++
			}
		}
		sum += freq * target
	}
	return sum
}
