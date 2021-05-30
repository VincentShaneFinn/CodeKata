import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtensionContext;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.*;

import java.util.stream.Stream;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.equalTo;

public class KarateChopTests {
    private KarateChop chopper;

    @BeforeEach
    public void setUp() {
        chopper = new KarateChop();
    }

    @ParameterizedTest
    @MethodSource("localParameters")
    @ArgumentsSource(CustomArgumentProvider.class)
    public void Find_target_index_in_array(int target, int targetIndex, int[] array){
        assertThat(chopper.chop(target, array), equalTo(targetIndex));
    }

    static class CustomArgumentProvider implements ArgumentsProvider {
        @Override
        public Stream<? extends Arguments> provideArguments(ExtensionContext context) throws Exception {
            return Stream.of(
                    Arguments.of(0, 0, new int[] {0,1,2})
            );
        }
    }

    public static Stream<Arguments> localParameters()
    {
        return Stream.of(
                Arguments.of(0, 0, new int[] {0,1,2}),
                Arguments.of(4, 4, new int[] {0,1,2,3,4,5,6})
        );
    }

    @Test
    public void Find_target_index_in_array_1(){
        assertThat(chopper.chop(0, new int[] {0,1,2}), equalTo(0));
    }
}
