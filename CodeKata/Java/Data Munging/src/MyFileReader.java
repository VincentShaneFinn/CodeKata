import javax.imageio.IIOException;
import java.io.*;

public class MyFileReader {

    private String filePath;
    private Reader reader;
    private BufferedReader bufferedReader;

    public MyFileReader(String fileName) throws FileNotFoundException {
        filePath = "in/" + fileName;

        reader = new FileReader(filePath);
        bufferedReader = new BufferedReader(reader);
    }

    public String readLine() throws IOException {
        return bufferedReader.readLine();
    }
}
