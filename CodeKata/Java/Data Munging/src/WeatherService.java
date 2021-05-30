import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class WeatherService {

    private MyFileReader reader;

    public WeatherService(MyFileReader reader) {
        this.reader = reader;
    }

    public List<Weather> get() {
        var list = new ArrayList<Weather>();
        String line;

        try {
            reader.readLine();
            while((line = reader.readLine()) != null){
                var array = line.trim().split("\\s+");
                if(line.isEmpty()) continue;
                var weather = getWeather(array);
                list.add(weather);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

        return list;
    }

    private Weather getWeather(String[] array) {
        var weather = new Weather();
        weather.id = array[0];
        weather.minTemperature = array[2];
        return weather;
    }
}
