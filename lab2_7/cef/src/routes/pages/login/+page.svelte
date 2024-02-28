<script lang="ts">
  import Icon from '@iconify/svelte';
  import { onDestroy, onMount } from "svelte";
  import { fade } from "svelte/transition";
  import { quintOut } from "svelte/easing";


  let email: string;
  let password: string;

  const tryLogin = async() => {
    if (email && password) {
      if (email.length < 1 || password.length < 1) {
        alert('Please fill in all fields');
        return;
      }

      await CefSharp.BindObjectAsync("boundAsync", "bound");
      boundAsync.loginUser(email, password);
      return;
    }

    alert('Please fill in all fields');
  }


  const changePasswordViewType = () => {
    const password = document.getElementById('password');
    if (password) {
      password.type = password.type === 'password' ? 'text' : 'password';
    }
  }

  const carouselPhotos = [
    '/images/Flights.png', '/images/Hotels.png', '/images/Hotels2.png'];

  let i = 0;
  function next() {
    i = (i+1) % carouselPhotos.length;
  }

  let timer;
  onMount(() => {
    let timer = setInterval(next, 3000);
  });
  onDestroy(() => {
    clearInterval(timer);
  });

  $: src = carouselPhotos[i];
</script>

<section>
  <div class="container">
    <div class="side">
      <div class="info">
        <div class="title">Login</div>
        <div class="description">Login to access your Golobe account</div>
      </div>
      <div class="main">
        <div class="inputs">
          <span>Email</span>
          <div class="block">
            <input type="text" name="" id="email" bind:value={email}>
          </div>
        </div>
        <div class="inputs">
          <span>Password</span>
          <div class="block">
            <input type="password" name="" id="password" bind:value={password}>
            <div class="icon" on:click={() => changePasswordViewType()}>
              <Icon icon="formkit:hidden" />
            </div>
          </div>
        </div>
        <div class="otherFeature">
          <div class="remember">
            <input type="checkbox">
            <span>Remember me</span>
          </div>
          <div class="forgot">
            <a href="/">Forgot password?</a>
          </div>
        </div>
      </div>
      <div class="button">
        <button on:click={() => tryLogin()}>Login</button>
      </div>
      <div class="signUp">
        <span>Don't have an account? <a href="/pages/register">Sign up</a></span>
      </div>
    </div>
    <div class="side" style="width: 30%">

      {#key src}
        <img
          transition:fade={{ delay:200, duration:1500 }}
          src="{src}"
          alt="Carousel of teachers' pics"
          class=""
        />
      {/key}
    </div>
  </div>
</section>

<style lang="scss">
  section {
    padding: 0 7.5%;

    padding-top: 30px;
    padding-bottom: 300px;
    
    .container {
      display: flex;
      flex-direction: row;
      justify-content: space-between;

      .side {
        width: 65%;

        display: flex;
        flex-direction: column;
        gap: 40px;

        position: relative;
        img {
          width: 100%;
          height: 100%;
          position: absolute;
        }

        .info {
          display: flex;
          flex-direction: column;
          line-height: 1.5;

          .title {
            font-size: 28px;
            font-weight: 700;
          }

          .description {
            font-size: 14px;
            font-weight: 500;
          }
        }

        .main {
          display: flex;
          flex-direction: column;
          gap: 10px;

          .inputs {
            display: flex;
            flex-direction: column;
            gap: 3px;

            span {
              font-size: 14px;
              font-weight: 500;
            }

            .block {
              position: relative;
              input {
                box-sizing: border-box;
                width: 100%;

                border: 1px solid rgba(23,23,23,0.5);
                background: transparent;
                border-radius: 6px;
                outline: none;

                padding: 10px;
              }

              .icon {
                font-size: 28px;

                position: absolute;

                top: 60%;
                right: 5px;

                transform: translate(0, -50%);
              }
            }
          }

          .otherFeature {
            display: flex;
            flex-direction: row;
            justify-content: space-between;
            align-items: center;

            .remember {
              display: flex;
              flex-direction: row;
              align-items: center;
              gap: 5px;

              input {
                width: 20px;
                height: 20px;  
              }
            }
          }
        }

        .button {
          button {
            width: 100%;
            box-sizing: border-box;  
            
            font-size: 16px;

            border: none;
            border-radius: 4px;

            padding: 10px 15px;

            background: #8DD3BB;
          }
        }

        .signUp {
          text-align: center;
        }
      }
    }
  }
</style>