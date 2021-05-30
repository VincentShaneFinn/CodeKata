import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.lang.reflect.Array;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.*;

public class MyFileReaderTests {

    private MyFileReader myFileReader;

    @BeforeEach
    void BeforeEach() throws FileNotFoundException {
        myFileReader = new MyFileReader("myFileReader.dat");
    }

    @Test
    void ReadLine_returns_the_first_line() throws IOException {
        String firstLine = myFileReader.readLine();

        assertThat(firstLine, is("Can you read this?"));
    }

    @Test
    void ReadLine_return_the_second_line_after_first_line_is_read() throws IOException {
        myFileReader.readLine();
        String secondLine = myFileReader.readLine();

        assertThat(secondLine, is("How about this?"));
    }

    @Test
    void ReadLine_after_end_of_file_return_null() throws IOException {
        myFileReader.readLine();
        myFileReader.readLine();

        String afterFileReadLine = myFileReader.readLine();
        assertThat(afterFileReadLine, nullValue());
    }
}
