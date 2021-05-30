package com.vpp.isbntools;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.Mockito.*;

public class StockManagerTests {

    IExternalISBNDataService testWebService = mock(IExternalISBNDataService.class);
    IExternalISBNDataService testDataService = mock(IExternalISBNDataService.class);

    @Test
    public void test_can_get_a_correct_locator_code() {
        String isbn = "0140177396";
        StockManager stockManager = new StockManager();
        stockManager.setWebService(testWebService);
        stockManager.setDataService(testDataService);
        when(testDataService.lookup(isbn)).thenReturn(new Book(isbn, "Of Mice and Men", "J. Steinbeck"));

        String locatorCode = stockManager.getLocatorCode(isbn);

        assertEquals("7396J4", locatorCode);
    }

    @Test
    public void databaseService_is_used_if_data_is_present() {
        String isbn = "0140177396";
        StockManager stockManager = new StockManager();
        stockManager.setWebService(testWebService);
        stockManager.setDataService(testDataService);
        when(testDataService.lookup(isbn)).thenReturn(new Book(isbn, "abc", "abc"));

        String locatorCode = stockManager.getLocatorCode(isbn);

        verify(testDataService, times(1)).lookup(isbn);
        verify(testWebService, times(0)).lookup(isbn);
    }

    @Test
    public void webService_is_used_if_data_is_not_present(){
        String isbn = "0140177396";
        StockManager stockManager = new StockManager();
        stockManager.setWebService(testWebService);
        stockManager.setDataService(testDataService);
        when(testWebService.lookup(isbn)).thenReturn(new Book(isbn, "abc", "abc"));

        String locatorCode = stockManager.getLocatorCode(isbn);

        verify(testDataService, times(1)).lookup(isbn);
        verify(testWebService, times(1)).lookup(isbn);
    }
}
