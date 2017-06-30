<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>

<h2 class="pageheading">Login</h2>
<div id="login-form" class="container-fluid text-center">
	<form action="login" method="POST">
		<fieldset>
			<div class="input-group">
				<c:if test="${not empty requestScope.msg}">
					${requestScope.msg}
				</c:if>

				<c:choose>
					<c:when test="${not empty cookie.rmbUsername}">
						<span class="input-group-addon"><span
							class="fa fa-user fa-fw"></span></span>
						<input type="text" class="form-control" id="username"
							placeholder="Username" autocomplete="off" required="required"
							name="username" value="${cookie.rmbUsername.value}">
					</c:when>
					<c:otherwise>
						<span class="input-group-addon"><span
							class="fa fa-user fa-fw"></span></span>
						<input type="text" class="form-control" id="username"
							placeholder="Username" autocomplete="off" required="required"
							name="username">
					</c:otherwise>
				</c:choose>

			</div>
			<br />

			<div class="input-group">
				<span class="input-group-addon"><span
					class="fa fa-lock fa-fw"></span></span> <input id="password"
					type="password" class="form-control" placeholder="Password"
					required="required" name="password">
			</div>
			<br />

			<div class="checkbox">
				<c:choose>
					<c:when test="${not empty cookie.rmbUsername}">
						<input name="rememberme" type="checkbox" class="styled" checked="checked" /> 
					</c:when>
					<c:otherwise>
						<input name="rememberme" type="checkbox" class="styled"  /> 
					</c:otherwise>
				</c:choose>
				<label>Remember Me</label>
			</div>

			<br /> <a class="btn btn-default" href="index.jsp">Cancel</a>
			<button type="submit" class="btn btn-default submit-btn">Login</button>


		</fieldset>
		<br />

		<div id="login-help">
			<a href="index.jsp?page=passwordrecovery"> Lost your password? </a> <br /> <a
				href="index.jsp?page=register"> Register </a> <br />
		</div>
	</form>
</div>