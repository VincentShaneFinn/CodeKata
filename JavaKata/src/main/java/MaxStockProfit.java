import java.util.ArrayList;

public class MaxStockProfit {
    public static int[][] compute(int[] input, int k) {
        var output = new ArrayList<int[]>();

        Integer buy = null;
        Integer sell = null;

        for(int i = 0; i < input.length; i++) {
            Integer previous = i != 0 ? input[i - 1] : null;
            Integer current = input[i];
            Integer next = i + 1 != input.length ? input[i + 1] : null;


            if(next == null) {
                if(buy != null) {
                    //and if sell is not null, make pair, or if current is greater than previous add sell
                    if(sell == null && current > previous) sell = current;
                    if(sell != null) output.add(new int[] {buy, sell});
                }
                break;
            }

            if(current < next && buy == null) buy = current;
            if(previous != null && current > previous && buy != null) sell = current;
            if(previous != null && next != null) {
                if(previous < current && current > next) {
                    if(buy != null && sell != null) {
                        output.add(new int[] {buy, sell});
                        sell = null;
                        buy = null;
                    }
                }
            }
            System.out.println(buy);
            System.out.println(sell);
        }


        int[][] outputArray = output.toArray(new int[output.size()][]);
        return outputArray;
    }
}
