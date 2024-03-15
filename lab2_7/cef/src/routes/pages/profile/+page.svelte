<script lang="ts">
  import Icon from '@iconify/svelte';
  import { onMount } from 'svelte';
  import { name, email } from '../../states';

  import Account from './account.svelte';
  import Tickets  from './tickets.svelte'

  let activePage = 0;
  let nav: HTMLElement | null = null;

  const changeActivePage = (page: number) => {
    if (nav) {
      const list = nav.querySelectorAll('li');
      
      if (list[activePage].classList.contains('active')) {
        nav.querySelectorAll('li')[activePage].classList.remove('active');
      }
      nav.querySelectorAll('li')[page].classList.add('active');
      console.log('mark acitve')
    }
    activePage = page;
  }

  onMount(() => {
    nav = document.getElementById('navigation');
  })
</script>

<svelte:head>
  <title>Profile</title>
</svelte:head>

<section>
  <header>
    <div class="background">
      <img src="/images/profile/header.png" alt="">
    </div>

    <div class="info">
      <img src="/images/profile/user.png" alt="">
      <div class="text">
        <span>{$name}</span>
        <span>{$email}</span>
      </div>
    </div>
  </header>

  <nav id="navigation">
    <li class="active" on:click={() => changeActivePage(0)}>Account</li>
    <li class="" on:click={() => changeActivePage(1)}>Tickets/Booking</li>
  </nav>

  <main>
    {#if activePage == 0}
      <div class="title">
        Account
      </div>
      <Account />
    {:else}
      <div class="title">
        Tickets/Booking
      </div>
       <Tickets />
    {/if}
  </main>
</section>

<style lang="scss">
  section {
    padding: 0 7.5%;
    padding-bottom: 200px;

    display: flex;
    flex-direction: column;
    gap: 30px;

    header {
      width: 100%;
      height: auto;
      
      .background {
        width: 100%;
        height: auto;

        img {
          width: 100%;
        }
      }

      .info {
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;

        gap: 10px;

        margin-top: -70px;

        img {
          width: 120px;
          height: 120px;
        }

        .text {
          display: flex;
          flex-direction: column;
          justify-content: center;
          align-items: center;

          font-weight: 500;
          font-size: 16px;
          gap: 3px;

          span:nth-child(1) {
            font-size: 24px;
            font-weight: 700;
          }
        }
      }
    }

    nav {
      display: flex;
      flex-direction: row;
      justify-content: start;
      align-items: center;

      background: #FFF;
      border-radius: 12px;

      padding: 20px;

      .active {
        color: #8DD3BB;
      }
      li {
        width: 50%;

        list-style: none;

        font-size: 20px;
        font-weight: 700;
        color: #000;

        transition: color ease-in-out 0.3s;

      }
    }

    main {
      display: flex;
      flex-direction: column;
      gap: 20px;
      .title {
        font-size: 28px;
        font-weight: 700;
      }
    }
  }
</style>