<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Index</title>

<!--  BOOTSTRAP  -->
<link href="css/bootstrap.css" rel="stylesheet">
<script
	src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
<script src="js/bootstrap.js"></script>

<!-- FONT AWESOME -->
<link href="css/font-awesome.css" rel="stylesheet">

<!-- AWESOME CHECKBOX -->
<link href="css/awesome-bootstrap-checkbox.css" rel="stylesheet">

<!-- CUSTOM -->
<link href="css/main.css" rel="stylesheet">
<link href="css/header.css" rel="stylesheet">
<link href="css/form.css" rel="stylesheet">
<script src= "js/formvalidation.js"></script>

</head>
<body>
	<jsp:include page="WEB-INF/webapp/header.jsp" />
	<jsp:include page="WEB-INF/webapp/message.jsp"></jsp:include>
	<c:choose>
		<c:when test="${param.page == 'login' }">
			<jsp:include page = "WEB-INF/webapp/login.jsp"/>
		</c:when>
		<c:when test="${param.page == 'register' }">
			<jsp:include page = "WEB-INF/webapp/register.jsp"/>
		</c:when>
		<c:otherwise>
			<jsp:include page = "WEB-INF/webapp/home.jsp"/>
		</c:otherwise>
	</c:choose>
</body>