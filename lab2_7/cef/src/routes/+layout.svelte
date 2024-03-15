<script lang="ts">
	import { onMount } from 'svelte';
	import { goto } from '$app/navigation';
	import { name, email, popupData } from './states';
	import { writable } from 'svelte/store'

	import PopUp from './components/changeInfoPopUp.svelte';

	import Header from './components/header.svelte';
	import Footer from './components/footer.svelte';
	import './styles.css';

	// Supports weights 100-900
	import '@fontsource-variable/montserrat';

	onMount(() => {
		window.playerLogin = function(userName: string, userEmail: string) {
			name.set(userName);
			email.set(userEmail);

			goto('/');
		}

    window.showError = function(message: string) {
      alert(message);
    }
	})
</script>
{#if $popupData.title !== ''}
	<PopUp />
{/if}

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
