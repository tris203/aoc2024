package days

import "fmt"

type Solution interface {
	Part1(string) any
	Part2(string) any
}

var registeredDays = map[int]func() Solution{}

func Register(day int, fn func() Solution) {
	if _, exists := registeredDays[day]; exists {
		panic(fmt.Sprintf("day %d already registered", day))
	}
	registeredDays[day] = fn
}

func GetSolution(day int) (Solution, error) {
	if fn, exists := registeredDays[day]; exists {
		return fn(), nil
	}
	return nil, fmt.Errorf("day %d not registered", day)
}
