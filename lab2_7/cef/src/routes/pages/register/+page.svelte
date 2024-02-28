<script lang="ts">
  import Icon from '@iconify/svelte';
  import { onDestroy, onMount } from "svelte";
  import { fade } from "svelte/transition";
  import { quintOut } from "svelte/easing";

  let email: string;
  let password: string;
  let phoneNumber: string;
  let name: string;
  let surname: string;
  let confirmPassword: string;

  let isAgreeTerms: boolean = false;

  const tryRegister = async() => {
    if (email && password && phoneNumber && name && surname && confirmPassword) {
      if (!isAgreeTerms) {
        alert('Please agree to all terms and conditions');
        return;
      }

      if (email.length < 1 || password.length < 1 || phoneNumber.length < 1 || name.length < 1 || surname.length < 1 || confirmPassword.length < 1) {
        alert('Please fill in all fields');
        console.log('err');
        return;
      }

      if (password !== confirmPassword) {
        alert('Passwords do not match');
        return;
      }

      await CefSharp.BindObjectAsync("boundAsync", "bound");
      boundAsync.registerUser(name, surname, email, phoneNumber, password);
    }
    else {
      alert('Please fill in all fields');
      console.log('err');
      return;
    }
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
    <div class="left">

      {#key src}
        <img
          transition:fade={{ delay:200, duration:1500 }}
          src="{src}"
          alt="Carousel of teachers' pics"
          class=""
        />
      {/key}
    </div>
    <div class="right">
      <div class="info">
        <div class="title">Sign up</div>
        <div class="description">Let’s get you all st up so you can access your personal account.</div>
      </div>
      <div class="main">
        <div class="textInput">
          <div class="element">
            <span>First Name</span>
            <input type="text" name="" id="" bind:value={name}>
          </div>
          <div class="element">
            <span>Last Name</span>
            <input type="text" name="" id="" bind:value={surname}>
          </div>
        </div>
        <div class="textInput">
          <div class="element">
            <span>Email</span>
            <input type="email" name="" id="" bind:value={email}>
          </div>
          <div class="element">
            <span>Phone number</span>
            <input type="tel" name="" id="" bind:value={phoneNumber}>
          </div>
        </div>
        <div class="password">
          <span>Password</span>
          <div class="block">
            <input type="password" name="" id="password" bind:value={password}>
            <div class="icon" on:click={() => changePasswordViewType()}>
              <Icon icon="formkit:hidden" />
            </div>
          </div>
        </div>
        <div class="password">
          <span>Confirm password</span>
          <div class="block">
            <input type="password" name="" id="password" bind:value={confirmPassword}>
            <div class="icon" on:click={() => changePasswordViewType()}>
              <Icon icon="formkit:hidden" />
            </div>
          </div>
        </div>
        <div class="otherFeature">
          <div class="remember">
            <input type="checkbox" bind:checked={isAgreeTerms}>
            <span>I agree to all <a href="/">Terms</a> and <a href="/">Privacy Policies</a></span>
          </div>
        </div>
      </div>
      <div class="button">
        <button on:click={() => tryRegister()}>Create account</button>
      </div>
      <div class="signUp">
        <span>Already have an account? <a href="/pages/login">Login</a></span>
      </div>
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

      .left {
        width: 30%;

        display: flex;
        flex-direction: column;
        gap: 10px;

        position: relative;
        img {
          width: 100%;
          height: 100%;
          position: absolute;
        }
      }

      .right {
        width: 68%;

        display: flex;
        flex-direction: column;
        gap: 10px;

        position: relative;

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

          .textInput {
            display: flex;
            justify-content: space-between;

            .element {
              width: 48%;
              display: flex;
              flex-direction: column;
              gap: 3px;

              span {
                font-size: 14px;
                font-weight: 500;
              }

              input {
                box-sizing: border-box;
                width: 100%;

                border: 1px solid rgba(23,23,23,0.5);
                background: transparent;
                border-radius: 6px;
                outline: none;

                padding: 10px;
              }
            }
          }

          .password {
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