import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.io.IOException;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.is;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class WeatherServiceTests {

    final String headerRow = " Id  Max  Min";
    final String emptyRow = "";
    final String firstRow =  " 0   100  50";
    final String secondRow = " 1   90   60";

    private MyFileReader reader;

    private WeatherService service;

    @BeforeEach
    void BeforeEach() throws IOException {
        reader = mock(MyFileReader.class);
        when(reader.readLine()).thenReturn(headerRow, firstRow, secondRow, null);

        service = new WeatherService(reader);
    }

    //TODO: someone else determine what a valid row is and pass it to method that returns weather
    @Test void Ignores_header_row(){

    }

    @Test void Ignores_empty_row() {

    }

    @Test
    void Maps_first_row_day_number_from_read_file() {
        var model = service.get();

        var firstWeather = model.get(0);
        assertThat(firstWeather.id, is("0"));
    }

    @Test
    void Maps_second_row_day_number_from_read_file() {
        var model = service.get();

        var secondWeather = model.get(1);
        assertThat(secondWeather.id, is("1"));
    }

    @Test
    void Maps_first_row_min_temperature_from_read_file() {
        var model = service.get();

        var firstWeather = model.get(0);
        assertThat(firstWeather.minTemperature, is("50"));
    }

    @Test
    void Maps_second_row_min_temperature_from_read_file() {
        var model = service.get();

        var secondWeather = model.get(1);
        assertThat(secondWeather.minTemperature, is("60"));
    }
}
