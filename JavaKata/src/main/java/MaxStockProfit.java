import java.util.ArrayList;

public class MaxStockProfit {
    public static int[][] compute(int[] input, int k) {
        var output = new ArrayList<int[]>();

        int direction = 0;
        Integer previous = null;
        Integer buy = null;
        Integer sell = null;

        for(int current : input) {
            int newDirection;
            if(previous == null) continue;
            if(current < previous) newDirection = -1;
            else if (current == previous) newDirection = 0;
            else newDirection = 1;

            if(direction == -1 && newDirection == 1) buy = current;
            if(direction == 1 && newDirection == -1 && buy != null) sell = current;

            direction = newDirection;

            if(buy != null && sell != null) {
                output.add(new int[]{buy, sell});
                buy = null;
                sell = null;
            }
        }

        int[][] outputArray = new int[][] {};
        output.toArray(outputArray);
        return outputArray;
    }
}
