function showEditForm(commentId, postId) {
	//console.log("iskam da pokaja edit menuto na komentar s id ", id, " 😭😭😭😭😭😭😭😭😭😭 no sum tvurde tup i ne moga :(((((((((");

    let editFormHtml = '<form method="post" action="/post/editComment"> \
		<input type="hidden" name="postId" value="'+postId+' /> \
		<input type="hidden" name="commentId" value="'+commentId+' /> \
		<input type="text" name="content"/> \
		<input type="submit"/> \
		</form>';
	let editMenu = document.createElement("div")
	editMenu.innerHTML = editFormHtml;

	document.getElementsByTagName("comment" + commentId).appendChild(editMenu);
}