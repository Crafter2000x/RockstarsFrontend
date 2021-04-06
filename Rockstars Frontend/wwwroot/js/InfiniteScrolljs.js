const container = document.getElementById('container');
const loading = document.querySelector('.loading');

getPost(i);
getPost(i);
getPost(i);
getPost(i);
getPost(i);
getPost(i);

window.addEventListener('scroll', () => {
	const { scrollTop, scrollHeight, clientHeight } = document.documentElement;

	console.log({ scrollTop, scrollHeight, clientHeight });

	if (clientHeight + scrollTop >= scrollHeight - 5) {
		// show the loading animation
		showLoading();
	}
});

async function getPost(i) {
	//const postResponse = await fetch(`https://jsonplaceholder.typicode.com/posts/3467`);
	//const postData = await postResponse.json;
	//const data = { post: postData };
	AddDataToDOM(i);
}
function showLoading() {
	loading.classList.add('show');

	// load more data
	setTimeout(getPost, 1000)
}
function AddDataToDOM(i) {
	const postElement = document.createElement('div');
	postElement.classList.add('artikel');
	postElement.innerHTML = `
		<img src="@Imageurl" /> @thumbnail
                        <div class="Titel">
                            <h2>@artikel.title.ToUpper()</h2> ${i}
                        </div>
                        <div class="info">
                            <h3><i class="fa fa-pencil"></i>&nbsp; &nbsp;@artikel.author</h3>
                            <h3><i class="fa fa-calendar-o"></i>&nbsp; &nbsp;@artikel.createdDate.ToString("dd-MM-yyyy")</h3>@*artikel.author + artikel.createdDate*@
                        </div>
	`;
	container.appendChild(postElement);

	loading.classList.remove('show');
}