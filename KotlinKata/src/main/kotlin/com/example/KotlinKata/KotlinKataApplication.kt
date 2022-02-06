package com.example.KotlinKata

import org.springframework.boot.autoconfigure.SpringBootApplication
import org.springframework.boot.runApplication

@SpringBootApplication
class KotlinKataApplication

fun main(args: Array<String>) {
	runApplication<KotlinKataApplication>(*args)
}
