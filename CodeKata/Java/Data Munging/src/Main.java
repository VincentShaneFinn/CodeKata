import java.io.FileNotFoundException;

public class Main {
    public static void main(String[] args) throws FileNotFoundException {
        var reader = new MyFileReader("weather.dat");
        var weatherService = new WeatherService(reader);
        var weatherList = weatherService.get();

        for(var weather : weatherList){
            System.out.println("Day Number: " + weather.id + " | Min Temperature: " + weather.minTemperature);
        }
    }
}
