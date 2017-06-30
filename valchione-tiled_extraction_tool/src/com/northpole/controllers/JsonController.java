package com.northpole.controllers;

import java.io.File;
import java.io.IOException;
import java.io.Writer;

import org.codehaus.jackson.JsonGenerationException;
import org.codehaus.jackson.JsonNode;
import org.codehaus.jackson.JsonProcessingException;
import org.codehaus.jackson.map.JsonMappingException;
import org.codehaus.jackson.map.ObjectMapper;

import com.northpole.dto.Dto;

public class JsonController {
	public static void writeJsonToFile(Dto dto, Writer out){
		ObjectMapper mapper = new ObjectMapper();
		
		try{
			mapper.writeValue(out, dto);
			
		}
		catch(JsonGenerationException e){
			e.printStackTrace();
		} catch (JsonMappingException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	
	public static String toJsonString(Dto dto){
		ObjectMapper mapper = new ObjectMapper();
		String output = null;
		
		try{
			output=  mapper.writeValueAsString(dto);
		}
		catch(JsonGenerationException e){
			e.printStackTrace();
		} catch (JsonMappingException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return output;
	}
	
	public static JsonNode getJsonNodeObj(String filename){
		ObjectMapper mapper = new ObjectMapper();
		JsonNode rootNode = null;
		try {
			rootNode = mapper.readValue(new File(filename), JsonNode.class);
		} catch (JsonProcessingException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		} 
		
		return rootNode;
	}
}
