<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>

<h2 class="pageheading">Register</h2>

<div id="login-form" class="container-fluid text-center">
	<form action="#" method="POST">
		<fieldset>
			<div class="input-group">
				<div class="input-group">
					<span class="input-group-addon"><span
						class="fa fa-user fa-fw"></span></span> <input id="first-name" type="text"
						class="form-control" placeholder="First Name" autocomplete="off"
						required="required" name="firstname">
				</div>
				<br />
	
				<div class="input-group">
					<span class="input-group-addon"><span
						class="fa fa-user fa-fw"></span></span> <input id="last-name" type="text"
						class="form-control" placeholder="Last Name" autocomplete="off"
						required="required" name="lastname">
				</div>
				<br />
	
				<div class="input-group">
					<span class="input-group-addon"><span
						class="fa fa-user fa-fw"></span></span> <input id="username" type="text"
						class="form-control" placeholder="Create a username"
						autocomplete="off" required="required" name="username">
				</div>
				<br />
	
				<div class="input-group">
					<span class="input-group-addon"><span
						class="fa fa-envelope fa-fw"></span></span> <input id="email" type="text"
						class="form-control email" placeholder="Email"
						onchange="emailValidationMsg(this)" autocomplete="off"
						required="required">
				</div>
				<br />
	
				<div class="input-group">
					<span class="input-group-addon"><span
						class="fa fa-lock fa-fw"></span></span> <input id="password"
						type="password" class="form-control password"
						placeholder="Create a password"
						onchange="passwordValidationMsg(this)" autocomplete="off"
						required="required">
				</div>
				<br />
	
	
				<div class="input-group">
					<span class="input-group-addon"><span
						class="fa fa-lock fa-fw"></span></span> <input id="password-confirm"
						type="password" class="form-control password-confirm"
						placeholder="Confirm your password"
						onchange="passwordConfValidationMsg(this)" autocomplete="off"
						required="required" name="password">
				</div>
				<br /> <br />
	
				<div class="checkbox">
					<input type="checkbox" required="required" class="styled" /> <label>
						I accept <a href="index.jsp?page=termsandconds" target="_blank">TP's
							terms and conditions</a>
					</label>
				</div>
	
	
	
				<br /> <br /> <a class="btn btn-default" href="index.jsp">Cancel</a>
				<button type="submit" class="btn btn-default submit-btn">Register</button>
				</div>
		</fieldset>
	</form>
</div>