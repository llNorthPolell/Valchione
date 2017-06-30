<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>

<div class="container text-center">
	<p class="errormsg">${sessionScope.msg }</p>
	<c:remove var="msg" scope="session" />
</div>