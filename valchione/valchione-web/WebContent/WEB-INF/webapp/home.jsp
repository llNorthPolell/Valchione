<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Home</title>

</head>
<body>
	<div id="maincarousel" class="carousel slide" data-ride="carousel">
		<ol class="carousel-indicators">
			<li data-target="#main1" data-slide-to="0" class="active"></li>
			<li data-target="#main2" data-slide-to="1"></li>
		</ol>
	
	
		<div class="carousel-inner">
			<div class="item active" data-id="0">
				<img src="img/0.png" alt="In Progress" />
				<div class="carousel-caption">
					<h1>In Progress</h1>
					<p>
						This is still in progress. Sign up early today to avoid the hassle!  &nbsp; <a
							class="btn btn-default heavybtn" href="#"> Sign Up  </a>
					</p>
				</div>
			</div>
			<div class="item" data-id="1">
				<img src="img/1.png" alt="In Progress" />
				<div class="carousel-caption">
					<h1>New Character and Card in Progress! </h1>
					<p>
						Third Character is on its way to join in the fight to claim Valchione! With his firey rage, legends have it that he can split the 
						a mountain in half with one swing of his blade.  &nbsp; <a
							class="btn btn-default heavybtn" href="#"> Read More  </a>
					</p>
				</div>
			</div>
		</div>
	
		<a class="left carousel-control" href="#maincarousel"
			data-slide="prev"> <span class="glyphicon glyphicon-chevron-left"></span>
			<span class="sr-only">Previous</span>
		</a> <a class="right carousel-control" href="#maincarousel"
			data-slide="next"> <span class="glyphicon glyphicon-chevron-right"></span>
			<span class="sr-only">Next</span>
		</a>
	</div>
	
	
	<div id ="newsfeed">
		<ul>
			<li>
				<h4> July 30, 2016 11:12pm</h4>
				<h2> Test Post </h2>
				<p> This is a test. Test test test...</p>
				<br/>
			</li>
			<li>
				<h4> July 30, 2016 11:10pm</h4>
				<h2> Land of Snow Project Initiated </h2>
				<p> The website for Land of Snow is up! Game is currently in progress as well. See you soon!</p>
				<br/>
			</li>
		</ul>
	</div>
</body>
</html>