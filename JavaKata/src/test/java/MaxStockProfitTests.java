import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;

public class MaxStockProfitTests {

    @Test
    public void example1() {
        var input = new int[] { 2, 4, 7, 5, 4, 3, 5 };
        var k = 2;

        int[][] result = MaxStockProfit.compute(input, k);

        assertThat(result).isEqualTo(new int[][] { { 2, 7 }, { 3, 5 } });
    }

    @Test
    public void example2() {
        var input = new int[] { 1, 5, 2, 3, 7, 6, 4, 5 };
        var k = 3;

        int[][] result = MaxStockProfit.compute(input, k);

        assertThat(result).isEqualTo(new int[][] { { 1, 5 }, { 2, 7 }, { 4, 5 } });
    }

    @Test
    public void example3() {
        var input = new int[] {10, 6, 8, 4, 2};
        var k = 2;

        int[][] result = MaxStockProfit.compute(input, k);

        assertThat(result).isEqualTo(new int[][] { { 6, 8 } });
    }

    @Test
    public void example4() {
        var input = new int[] { 10, 8, 6, 5, 4, 2 };
        var k = 1;

        int[][] result = MaxStockProfit.compute(input, k);

        assertThat(result).isEqualTo(new int[][] {});
    }
}
