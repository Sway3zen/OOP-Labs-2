<script lang="ts">
	import './assets/styles/home.scss'

	// import Counter from './Counter.svelte';
	import Icon from '@iconify/svelte';
	import FindTicket from './components/findTicket.svelte';
</script>

<svelte:head>
	<title>Home</title>
	<meta name="description" content="Svelte demo app" />
</svelte:head>

<section id="home">
	<div class="findTicket">
		<div class="header">
			<img src="/images/homeHeader.png" alt="">
			<div class="text">
				<span>Helping Others</span>
				<span>Live & Travel</span>
				<span>Special offers to suit your plan</span>
			</div>
		</div>

		<div class="chooseTicket">
			<FindTicket />
		</div>
	</div>
	<div class="container">
		<div class="perfectTrip">
			<div class="titleBlock">
				<div class="left">
					<div class="title">Plan your perfect trip</div>
					<div class="description">Search Flights & Places Hire to our most popular destinations</div>
				</div>
				<div class="right">
					<button>See more places</button>
				</div>
			</div>

			<div class="trips">
				<div class="element">
					<div class="tripContainer">
						<div class="image">
							<img src="/images/trips/Istanbul.png" alt="">
						</div>
						<div class="text">
							<span class="title">Istanbul, Turkey</span>
							<div class="info">
								<li><span>Flights</span></li>
								<li><span>Hotels</span></li>
								<li><span>Resorts</span></li>
							</div>
						</div>
					</div>
				</div>
				<div class="element">
					<div class="tripContainer">
						<div class="image">
							<img src="/images/trips/Sydney.png" alt="">
						</div>
						<div class="text">
							<span class="title">Sydney, Australia</span>
							<div class="info">
								<li><span>Flights</span></li>
								<li><span>Hotels</span></li>
								<li><span>Resorts</span></li>
							</div>
						</div>
					</div>
				</div>
				<div class="element">
					<div class="tripContainer">
						<div class="image">
							<img src="/images/trips/Baku.png" alt="">
						</div>
						<div class="text">
							<span class="title">Baku, Azerbaijan</span>
							<div class="info">
								<li><span>Flights</span></li>
								<li><span>Hotels</span></li>
								<li><span>Resorts</span></li>
							</div>
						</div>
					</div>
				</div>
				<div class="element">
					<div class="tripContainer">
						<div class="image">
							<img src="/images/trips/Male.png" alt="">
						</div>
						<div class="text">
							<span class="title">Male, Maldives</span>
							<div class="info">
								<li><span>Flights</span></li>
								<li><span>Hotels</span></li>
								<li><span>Resorts</span></li>
							</div>
						</div>
					</div>
				</div>
				<div class="element">
					<div class="tripContainer">
						<div class="image">
							<img src="/images/trips/Paris.png" alt="">
						</div>
						<div class="text">
							<span class="title">Paris, France</span>
							<div class="info">
								<li><span>Flights</span></li>
								<li><span>Hotels</span></li>
								<li><span>Resorts</span></li>
							</div>
						</div>
					</div>
				</div>
				<div class="element">
					<div class="tripContainer">
						<div class="image">
							<img src="/images/trips/NewYork.png" alt="">
						</div>
						<div class="text">
							<span class="title">New York, US</span>
							<div class="info">
								<li><span>Flights</span></li>
								<li><span>Hotels</span></li>
								<li><span>Resorts</span></li>
							</div>
						</div>
					</div>
				</div>
				<div class="element">
					<div class="tripContainer">
						<div class="image">
							<img src="/images/trips/London.png" alt="">
						</div>
						<div class="text">
							<span class="title">London, UK</span>
							<div class="info">
								<li><span>Flights</span></li>
								<li><span>Hotels</span></li>
								<li><span>Resorts</span></li>
							</div>
						</div>
					</div>
				</div>
				<div class="element">
					<div class="tripContainer">
						<div class="image">
							<img src="/images/trips/Tokyo.png" alt="">
						</div>
						<div class="text">
							<span class="title">Tokyo, Japan</span>
							<div class="info">
								<li><span>Flights</span></li>
								<li><span>Hotels</span></li>
								<li><span>Resorts</span></li>
							</div>
						</div>
					</div>
				</div>
				<div class="element">
					<div class="tripContainer">
						<div class="image">
							<img src="/images/trips/Dubai.png" alt="">
						</div>
						<div class="text">
							<span class="title">Dubai, UAE</span>
							<div class="info">
								<li><span>Flights</span></li>
								<li><span>Hotels</span></li>
								<li><span>Resorts</span></li>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>

		<div class="selectType">
			<div class="element">
				<div class="image">
					<img src="/images/Flights.png" alt="">
				</div>
				<div class="info">
					<div class="text">
						<div class="title">Flights</div>
						<div class="description">
							Search Flights & Places Hire to our most popular destinations
						</div>
					</div>
					<button><Icon icon="basil:telegram-solid" /> Show Flights</button>
				</div>
			</div>

			<div class="element">
				<div class="image">
					<img src="/images/Hotels.png" alt="">
				</div>
				<div class="info">
					<div class="text">
						<div class="title">Hotels</div>
						<div class="description">
							Search hotels & Places Hire to our most popular destinations
						</div>
					</div>
					<button><Icon icon="basil:telegram-solid" /> Show Hotels</button>
				</div>
			</div>
		</div>
	</div>
</section>
