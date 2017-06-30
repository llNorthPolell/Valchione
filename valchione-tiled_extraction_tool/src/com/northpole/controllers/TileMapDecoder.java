package com.northpole.controllers;

import java.io.BufferedReader;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Base64;
import java.util.List;

public class TileMapDecoder {

	public static List<Integer> decode(String input, int width, int height) {
		byte[] decode = Base64.getDecoder().decode(input);

		
		List<Integer> gidList =  readDecoded(decode);
		
		

		return reverseEndianess(gidList);
	}

	
	private static List<Integer> readDecoded(byte[] input){
		ByteArrayInputStream byteArrayInputStream = new ByteArrayInputStream(input);
		List<Integer> output = new ArrayList<Integer>();
		try {
			InputStreamReader inputStreamReader = new InputStreamReader(byteArrayInputStream);
			BufferedReader bufferedReader = new BufferedReader(inputStreamReader, 4);

			int gid = 0;
			while ((gid = bufferedReader.read()) != -1)
				output.add(gid);

		} catch (IOException e) {
			e.printStackTrace();
		}
		
		return output;
	}
	
	private static List<Integer> reverseEndianess(List<Integer> input) {
		List<Integer> output = new ArrayList<Integer>();
		int[] temp = new int[4];
		int index = 0;
		for (Integer i : input) {
			temp[index] = i;
			index++;
			if (index == 4) {
				index = 0;
				int value = 1 * temp[0] + 10 * temp[1] + 100 * temp[2] + 1000 * temp[3];
				output.add(value);
				temp = new int[4];
			}

		}
		
		return output;
	}
}
