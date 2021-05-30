package com.vpp.isbntools;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

public class ValidateISBNTests {

    @Test
    public void check_valid_10_digit_ISBN() {
        ValidateISBN validator = new ValidateISBN();

        boolean actual = validator.checkISBN("0140449116");

        assertTrue(actual, "First Value");

        // OR

        actual = validator.checkISBN("0140177396");

        assertTrue(actual, "Second Value");
    }

    @Test
    public void check_valid_13_digit_ISBN() {
        ValidateISBN validator = new ValidateISBN();

        boolean actual = validator.checkISBN("9781853260087");

        assertTrue(actual, "First Value");

        // OR

        actual = validator.checkISBN("9781853267338");

        assertTrue(actual, "Second Value");
    }

    @Test
    public void ten_digit_number_ending_with_X_is_valid() {
        ValidateISBN validator = new ValidateISBN();

        boolean actual = validator.checkISBN("012000030X");

        assertTrue(actual);
    }

    @Test
    public void check_invalid_10_digit_ISBN() {
        ValidateISBN validator = new ValidateISBN();

        boolean actual = validator.checkISBN("9781853260086");

        assertFalse(actual);
    }

    @Test
    public void check_invalid_13_digit_ISBN() {
        ValidateISBN validator = new ValidateISBN();

        boolean actual = validator.checkISBN("0140449117");

        assertFalse(actual);
    }

    @Test
    public void ten_digit_ISBN_is_required() {
        ValidateISBN validator = new ValidateISBN();

        assertThrows(NumberFormatException.class, () -> validator.checkISBN("123456789"));
    }

    @Test
    public void non_numeric_is_not_allowed() {
        ValidateISBN validator = new ValidateISBN();

        assertThrows(NumberFormatException.class, () -> validator.checkISBN("helloworld"));
    }
}
