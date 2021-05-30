package com.vpp.isbntools;

public class ValidateISBN {

    private static final int SHORT_ISBN_LENGTH = 10;
    private static final int LONG_ISBN_LENGTH = 13;

    public boolean checkISBN(String number) {
        if(number.length() == LONG_ISBN_LENGTH) return isThisAValid13DigitISBN(number);
        else if (number.length() == SHORT_ISBN_LENGTH) return IsThisAValid10DigitISBN(number);
        else throw new NumberFormatException("number must be 10 or 13 digits");
    }

    private boolean IsThisAValid10DigitISBN(String number) {
        int total = 0;
        for (int i = 0; i < SHORT_ISBN_LENGTH; i++) {
            int value = number.charAt(i);
            if (!Character.isDigit(value)) {
                if (i == 9 && value == 'X') total += 10;
                else throw new NumberFormatException("Number can only contain digits");
            } else total += Character.getNumericValue(value) * (10 - i);
        }
        return total % 11 == 0;
    }

    private boolean isThisAValid13DigitISBN(String number) {
        int total = 0;
        for (int i = 0; i < LONG_ISBN_LENGTH; i++) {
            int value = Character.getNumericValue(number.charAt(i));
            boolean isEven = i % 2 == 0;
            if(isEven) total += value;
            else total += value * 3;
        }
        return total % 10 == 0;
    }
}
