package com.vpp.isbntools;

public class StockManager {
    private IExternalISBNDataService webService;
    private IExternalISBNDataService dataService;

    public void setWebService(IExternalISBNDataService webService) {
        this.webService = webService;
    }

    public void setDataService(IExternalISBNDataService dataService) {
        this.dataService = dataService;
    }

    public String getLocatorCode(String isbn) {
        Book book = dataService.lookup(isbn);
        if(book == null) book = webService.lookup(isbn);
        StringBuilder locatorBuilder = new StringBuilder();
        locatorBuilder.append(isbn.substring(isbn.length() - 4));
        locatorBuilder.append(book.getAuthor().substring(0,1));
        locatorBuilder.append(book.getTitle().split(" ").length);

        return locatorBuilder.toString();
    }
}
