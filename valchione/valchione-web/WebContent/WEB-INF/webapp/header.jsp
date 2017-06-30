<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>

<nav id = "accountBar" class="navbar navbar-default">
	<div class = "container">
		<ul id="accountNav" class="nav nav-pills navbar-right "> 
			<c:choose>
				<c:when test="${not empty sessionScope.user.username }">
					<li> 
						<h4 id= "helloMsg"> Hello ${sessionScope.user.username } !</h4>
					</li>
					<li>
						<a href="#"> Bazaar </a>
					</li>
					<li>
						<a href="#"> Account Services </a>
					</li>
					<li>
						<a href= "logout"> Logout </a>
					</li>
				</c:when>
				<c:otherwise>
					<li> 
						<a href= "index.jsp?page=login"> Login </a>
					</li>
					<li>
						<a href= "index.jsp?page=register"> Register </a>
					</li>
				</c:otherwise>
			</c:choose>		
		</ul>	
	</div>
</nav>

<div id = "gameLogo">
	<h1> Valchione </h1>	
</div>

<nav id = "headerbar" class="navbar navbar-default">
	<div class= "container">
		<ul id="headernav" class="nav nav-pills nav-justified">
			<li>
				<a href="index.jsp?page=home"> Home </a>
			</li>
			<li class= "dropdown">
				<a  class="dropdown-toggle" data-toggle="dropdown" href="#"> 
					Game  
					<span class="caret"></span>
				</a>
				<ul class="dropdown-menu">
					<li>
						<a href="#"> Lore</a>
					</li>
					<li>
						<a href="#"> Cards</a>
					</li>
				</ul>
			</li>
			<li>
				<a href="#"> Media</a>
			</li>
			<li>
				<a href="#"> Shop </a>
			</li>
			<li>
				<a href="#"> Forums</a>
			</li>
		</ul>
	</div>
</nav>

