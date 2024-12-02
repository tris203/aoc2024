package common

import (
	"fmt"
	"log"
	"os"
	"strings"
)

type Data struct {
	FilePath   string
	SamplePath string
}

func Load(day int, sample bool) string {
	dataType := "input"
	if sample {
		dataType = "sample"
	}
	path := fmt.Sprintf("../data/%02d/%s.txt", day, dataType)
	content, err := os.ReadFile(path)
	if err != nil {
		log.Fatal(err)
	}

	return strings.TrimSpace(string(content))
}
