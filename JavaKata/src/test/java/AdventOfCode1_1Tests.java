import org.junit.jupiter.api.Test;

import java.io.*;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;
import java.util.stream.Stream;

import static org.assertj.core.api.Assertions.assertThat;

public class AdventOfCode1_1Tests {
    @Test
    public void count_depth_increases()
    {
        var lines = List.of(1, 2, 1, 2);

        assertThat(countIncreases(lines)).isEqualTo(2);
    }

    @Test
    public void count_depth_increases_prod() throws IOException {
        try (Stream<String> stream = Files.lines(Paths.get("C:\\Users\\Finnx\\Desktop\\Coding\\CodeKata\\JavaKata\\src\\main\\resources\\input\\AdventOfCode1_1Input.txt"))) {
            var lines = stream.map(Integer::parseInt).toList();
            System.out.println(countIncreases(lines));
        }
    }

    private int countIncreases(List<Integer> lines) {
        var previous = lines.get(0);
        var result = 0;
        for(int i = 1; i < lines.size(); i++) {
            var current = lines.get(i);
            if (current > previous) {
               result++;
            }
            previous = current;
        }
        return result;
    }
}
