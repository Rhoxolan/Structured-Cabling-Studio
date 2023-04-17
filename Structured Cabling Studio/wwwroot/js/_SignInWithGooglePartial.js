document.addEventListener('click', e => {
    if (e.target.id === "signInWithGoogleA") {
        document.getElementById('signInWithGoogleForm').submit();
    }
});