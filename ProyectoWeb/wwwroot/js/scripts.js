window.onload = function () {
    alert("Bienvenido a Bookhub")
};
<script>
    { 
    const toggleButton = document.getElementById('toggleModo');
    const body = document.body;

    if (localStorage.getItem('modo') === 'oscuro') {
        body.classList.add('dark-mode');
    toggleButton.textContent = '☀️ Modo Diurno';
        }

        toggleButton.addEventListener('click', () => {
        body.classList.toggle('dark-mode');

    if (body.classList.contains('dark-mode')) {
        toggleButton.textContent = '☀️ Modo Diurno';
    localStorage.setItem('modo', 'oscuro');
            } else {
        toggleButton.textContent = '🌙 Modo Nocturno';
    localStorage.setItem('modo', 'claro');
            }
        });
</script>