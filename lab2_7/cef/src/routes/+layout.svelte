<script>
	import Header from './components/header.svelte';
	import Footer from './components/footer.svelte';
	import './styles.css';

	// Supports weights 100-900
	import '@fontsource-variable/montserrat';
</script>

<div class="app">
	<Header />

	<main>
		<slot />
	</main>

	<footer>
		<Footer />
	</footer>
</div>

<style>
	:global(body) {
		font-family: 'Montserrat Variable', sans-serif;
		
	}
	.app {
		display: flex;
		flex-direction: column;
		min-height: 100vh;
	}

	main {
		flex: 1;
		display: flex;
		flex-direction: column;
		width: 100%;
		box-sizing: border-box;
	}

	footer {
		display: flex;
		flex-direction: column;
		justify-content: center;
		align-items: center;

		padding-top: 50px;
	}



</style>
